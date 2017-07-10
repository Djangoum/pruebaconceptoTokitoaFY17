# IssueManager

Pasos para ejecutar.

1. Modificar la connection string en el fichero appsettings.json para que ataque al servidor sql deseado

2. Ejecutar las migrations definidas en el proyecto DataAccess con la siguiente instruccion :

Update-Database -Context IdentityContext

3. Ejecutar la aplicacion. 

4. Registrar un usuario en el formulario de la parte derecha y loguearlo en la parte izquierda. La primera vez recibireis un aviso de que el usuario no ha confirmado el correo electronico.

Con la siguiente instrucción pondreis el campo que almacena esta información a true 

  UPDATE [IssuesManager].[dbo].[AspNetUsers] SET EmailConfirmed = 1
  
ya podreis hacer login.

