chrome.app.runtime.onLaunched.addListener(function() {
  chrome.app.window.create('main.html', {
    bounds: {
      top: 100,
      left: 100,
      width: 640,
      height: 400
    }
  });
})
