# Cuestiones importantes para el uso

Version mínima de Android: Android 7.0

Version de Android probada: Android 10.0

Requiere uso del microfono, comprobar si la aplicacion de Google tiene permiso de microfono.

# Hitos de programación

Hemos logrado una escena con componentes complejos como los NPC que ademas poseen animaciones de movimiento, todo esto usando assets gratuitos

Desarrollamos una interfaz multimodal para comunicarnos con los NPC's donde se incluyen las siguientes tecnologias: 
- Uso de paquetes para la conversion a texto de la entrada del usuario y generac ion de audio en base a la respuesta generada por NPC que emplea las librerias de Android nativas.
- Uso de libreria de Android para comprobacion y solicitud de permisos asociados a la aplicación.
- Uso de directivas de compilador especificas para distincion de plataformas y consecuente asignacion de recursos.
- Uso de libreria que recae en la utilizacion de una api web para el procesado del texto de entrada del usuario.
- Uso de eventos para la ejecucion de determinadas funciones dependientes de determinadas acciones del usuario (inicio y finalizacion de conversacion).
- Uso de raycast para la deteccion de contacto visual entre el usuario y el NPC al que se dirige.
- Uso de herramienta externa para dotar de movimiento a las diferentes articulaciones de los NPC.
- Aprendimos a debugear aplicaciones de ejecucion nativas en Android.
- Uso de scriptable objects para almacenar informacion.

# Aspectos a destacar

- Rendimiento mayor al esperado: El speech-to-text y text-to-speech al ser implementados en librerias nativas de Android son muy rapidos.
- Sin embargo, la parte del procesado del texto de entrada dado por el usuario como recae en el uso de una API web introduce latencia en la ejecucion total del sistema.
- Los NPC estan descritos usando un scriptable object que contiene toda la informacion asociada a cada NPC individual (Nombre, genero, ocupacion, breve descripcion y ejemplos de conversacion).
- El contenido de la descripcion de los NPC y los ejemplos de la conversacion fueron generados usando ChatGPT

# Gif de la ejecución

![](https://github.com/alu0101325583/Gpt_Powered_Npcs_Vr_Demo/blob/main/Screen_Recording_20230118-202102_GPT3_Npcs_AdobeExpress.gif)

# Acta de los acuerdos del grupo

Juan: 
- Diseño de clases y desarrollo de codigo
- integracion y modificacion de las librerias y paquetes necesarios
- Prueba del correcto funcionamiento de la aplicación

Ayob: 
- Diseño e implementacion de la escena
- Busqueda e integracion de los assets
- Animacion de los modelos 3D

Grupo: 
- Elaboracion del Readme
- Elaboracion de la presentacion
- Generacion del contenido asociado a la informacion de los NPC
