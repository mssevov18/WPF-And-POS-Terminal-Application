int buttonPin = 7;
int buttwoPin = 8;
bool isOn = false;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.println();
  pinMode(buttonPin, OUTPUT);
  pinMode(buttwoPin, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if (digitalRead(buttonPin)==HIGH)
    Serial.println("True");
  if (digitalRead(buttwoPin)==HIGH)
    Serial.println("False");
  delay(50);
}
