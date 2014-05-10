#include <SPI.h>
#include <Ethernet.h>

EthernetServer server(80); 
byte      mac[] = { 0x90, 0xA2, 0xDA, 0x0D, 0x40, 0x02 };
IPAddress ip(192,168,100, 110);
int       ligaVermelho;
int       ligaAmarelo;
int       ligaVerde;

void setup(){
   Ethernet.begin(mac, ip);
   server.begin(); 
   pinMode(2,OUTPUT); 
   pinMode(3,OUTPUT); 
   pinMode(9,OUTPUT); 
   ligaVermelho = 0;
   ligaAmarelo  = 0;
   ligaVerde    = 0; 
}

void loop(){
   EthernetClient client = server.available(); //Servidor disponivel a receber chamadas
   if(client){ //Se tiver cliente conectado
     String get; //Cria um String essa String armazenará o que vem do cliente
     while(client.connected()){ //Inicia um laço, que repetirá enquanto houver o cliente conectado
         if(client.available()){ //Se tiver conexão com cliente
           char c = client.read(); //Le o que vem do cliente (neste caso vem Char por Char)
           get.concat(c); //Vai concatenando cada char que vem na String get
           if (c == '\n') { // o \n é simbolo de final de String, ou seja, o que tinha pra concatenar ja concatenou.
              if(get.substring(6,10) == "ve=1"){ 
                 ligaVermelho = 1; 
              }else{
                 if(get.substring(6,10) == "ve=0"){ 
                    ligaVermelho = 0; 
                 }
              }
              if(get.substring(6,10) == "am=1"){ 
                 ligaAmarelo = 1; 
              }else{
                 if(get.substring(6,10) == "am=0"){ 
                    ligaAmarelo = 0; 
                 }
              }
              if(get.substring(6,10) == "vd=1"){ 
                 ligaVerde = 1; 
              }else{
                 if(get.substring(6,10) == "vd=0"){ 
                    ligaVerde = 0; 
                 }
              }
              client.stop();
           }
         }
      }
      if(ligaVermelho == 1){// Vermelho
         digitalWrite(3, HIGH);
      }else{
         digitalWrite(3, LOW); 
      }
      
      if(ligaAmarelo == 1){// Amarelo
         digitalWrite(2, HIGH);
      }else{
         digitalWrite(2, LOW); 
      }
      
      if(ligaVerde == 1){// Verde
         digitalWrite(9, HIGH);
      }else{
         digitalWrite(9, LOW); 
      }
   }   
}
