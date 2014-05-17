var connectionId = -1;
var readBuffer = "";

function setPosition(position) {

  var buff = convertStringToArrayBuffer(position)
  chrome.serial.send(connectionId, buff, function() {});
};

var convertStringToArrayBuffer=function(str) {
  var buf=new ArrayBuffer(str.length);
  var bufView=new Uint8Array(buf);
  for (var i=0; i<str.length; i++) {
    bufView[i]=str.charCodeAt(i);
  }
  return buf;
};

function onRead(info) {
  var uint8View = new Uint8Array(info.data);

  var value = "";
  for(var i = 0; i < uint8View.length; i++) {
    value = value + String.fromCharCode(uint8View[i]);
  }

  setStatus('Connected') ;

  img = document.getElementById('image');
  if (value == "1") {
      document.getElementById('blinkCount').innerText = "ON";
      img.style.backgroundImage = "url(./assets/lamp3-on.png)";
  } else {
      document.getElementById('blinkCount').innerText = "OFF";
      img.style.backgroundImage = "url(./assets/lamp3-off.png)";
  }

}

function onOpen(openInfo) {
  connectionId = openInfo.connectionId;
  console.log("connectionId: " + connectionId);
  if (connectionId == -1) {
    setStatus('Could not open');
    return;
  }
  setStatus('Connected');

  setPosition(0);
};

function setStatus(status) {
  document.getElementById('status').innerText = status;
}

function buildPortPicker(ports) {

  var portPicker = document.getElementById('port-picker');

  ports.forEach(function(port) {
    var portOption = document.createElement('option');
    portOption.value = portOption.innerText = port.path;
    portPicker.appendChild(portOption);
  });

  portPicker.onchange = function() {
    if (connectionId != -1) {
      chrome.serial.close(connectionId, openSelectedPort);
      return;
    }
    openSelectedPort();
  };
}

function openSelectedPort() {
  var portPicker = document.getElementById('port-picker');
  var selectedPort = portPicker.options[portPicker.selectedIndex].value;
  chrome.serial.connect(selectedPort, {bitrate: 9600, dataBits: "eight", parityBit: "no", stopBits: "one"}, onOpen);
}

onload = function() {
  document.getElementById('position-input').onchange = function() {
    setPosition(this.value);
  };
  chrome.serial.getDevices(function(ports) {
    buildPortPicker(ports);
    openSelectedPort();
    chrome.serial.onReceive.addListener(onRead);
  });
};
