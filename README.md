# API PSP

## Nombre del Proyecto
API de PSP para el videojuego de GODOT

## Descripción del Proyecto
Esta API servirá para de momento registrar usuarios y logearlos a través de GODOT y en un futura para guardas las puntuaciones de los mismos.
### Documentos y sus Campos

1. **Usuario**

   - `id`: Identificador único del usuario generado automáticamente por MongoDB
   - `username`: Nombre del usuario
   - `password`: Contraseña cifrada

---

## Endpoints de la API

### **Autenticación**

1. **Registro de usuario** (`auth/register`)
   - Permite registrar un nuevo usuario en la aplicación.
   - Recibe username y password.

2. **Login de usuario** (`auth/login`)
   - Permite a los usuarios iniciar sesión.
   - Recibe username y password.
   - La idea es que devuelva un token JWT.

---

## PRUEBAS GESTIÓN USUARIOS

### Registrar un Usuario

- En este caso vamos a registrar un usuario mediante insomnia a nivel local antes de desplegar la API

<img src="API/Images/UsuarioRegistrado.png" alt="UsuarioRegistrado" width="1000"/>
<img src="API/Images/UsuarioRegistrado2.png" alt="UsuarioRegistrado2" width="1000"/>


### Logear con un Usuario

- En este caso vamos a logearnos con un usuario a nivel local.

<img src="API/Images/LoginUsuario.png" alt="LoginUsuario" width="1000"/>

### Aplicación desplegada en Render

<img src="API/Images/ApiRender.png" alt="ApiRender" width="1000"/>

### Registrar un Usuario en Render

- En este caso vamos a registrar un usuario mediante insomnia con la API desplegada

<img src="API/Images/RegisterRender.png" alt="RegisterRender" width="1000"/>
<img src="API/Images/RegisterRender2.png" alt="RegisterRender2" width="1000"/>

### Logear con un Usuario en Render

- En este caso vamos a logear un usuario mediante insomnia con la API desplegada

<img src="API/Images/LoginRender.png" alt="LoginRender" width="1000"/>