
# Flappy Bird 3D para Android y  PC

Este proyecto es un clon en 3D del famoso juego **Flappy Bird**, desarrollado como parte de la **Práctica 4: Desarrollo para móviles** del curso **Desarrollo de Entornos Interactivos Multidispositivo**. La aplicación está diseñada para dispositivos Android y PC adaptada según los requerimientos proporcionados.

## Características del Proyecto

1. **Personaje principal y cámara**:
   - El personaje recibe un impulso hacia arriba al tocar la pantalla o pulsar la barra espaciadora.
   - La cámara sigue al personaje en el eje X o Z.
   - Diferenciación entre los inputs de ordenador y móvil.

2. **Generación de tuberías con pools**:
   - Implementación de object pooling para optimizar el rendimiento.
   - Las tuberías se generan con alturas aleatorias al activarse.

3. **Sonidos y animaciones**:
   - Sonido al pasar por un hueco y al morir.
   - Animaciones de idle y muerte para el personaje principal.

4. **Interfaz gráfica (UI)**:
   - Contador de huecos atravesados visible en la pantalla.
   - Logo del juego en la esquina inferior izquierda.
   - Adaptación de la interfaz a diferentes resoluciones usando "Scale with screen size".
   - Fuente personalizada para los textos.

5. **Menú principal**:
   - Incluye botones de jugar, créditos y salir.
   - Botón para volver al menú desde la escena de juego.
   - El Game Manager no genera errores al cambiar de escena.

6. **Integración de Unity ADS**:
   - Aparece un anuncio cada 3-5 muertes.

7. **Optimizaciones**:
   - Uso de la herramienta Profiler para analizar rendimiento (FPS, memoria, etc.).
   - Modelos optimizados con un número reducido de polígonos.

## Proceso de Desarrollo

### 1. Configuración Inicial
- Creación del proyecto en Unity y configuración para dispositivos Android.
- Integración de Git para control de versiones.
- Adición de un archivo `.gitignore` para ignorar archivos generados automáticamente por Unity.

### 2. Desarrollo de la Jugabilidad
- Implementación del control del personaje principal.
- Generación de tuberías utilizando object pooling.
- Diseño y programación del sistema de puntos y UI.

### 3. Optimizaciones
- Análisis del rendimiento con Unity Profiler.
- Ajuste de los modelos 3D para mejorar la eficiencia.
- Integración de anuncios con Unity ADS.

### 4. Publicación en GitHub
- Configuración del repositorio remoto.
- Limpieza de archivos innecesarios mediante el uso de `.gitignore`.
- Sincronización del proyecto local con el repositorio remoto.

## Estructura del Proyecto
- **Assets/**: Contiene los recursos del juego, como modelos, texturas, sonidos y scripts.
- **Scenes/**: Escenas principales, incluyendo el menú y el juego.
- **Scripts/**: Scripts C# para la jugabilidad, el control del personaje, la generación de tuberías y la integración de anuncios.

## Requisitos
- **Unity**: Versión 2022.3.55f o superior.
- **Plataforma de destino**: Android y PC.
- **SDK de Unity Ads**: Configurado en el proyecto.

## Instalación
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/sadboy248030/FlappyBrid_Manrique_Diaz_Alfonso.git
   ```

2. Abrir el proyecto en Unity.
3. Configurar el entorno para Android (Player Settings).
4. Compilar y exportar el APK.

## Autor
- **Nombre**: Manrique Díaz Alfonso 😎
- **Actividad**: Práctica 4 - Desarrollo de Entornos Interactivos Multidispositivo

