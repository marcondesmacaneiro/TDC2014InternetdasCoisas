#define LED 13

int delayTime = 300;

void setup() {
  pinMode(LED, OUTPUT);
  Serial.begin(9600);
}

void loop() {
  
  digitalWrite(LED, HIGH);
  Serial.write("1");
  delay(delayTime);
  digitalWrite(LED, LOW);
  Serial.write("0");
  delay(500);
  
  if (Serial.available()) {
    int factor = Serial.read() - 48;
    delayTime = map(factor, 0, 9, 300, 2000);
  }
}
