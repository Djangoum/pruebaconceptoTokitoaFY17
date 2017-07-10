App.config(["$translateProvider", function ($translateProvider) {

    var translationsen = {
        LOGINTITLE: 'Log In',
        EMAILADDRESS: 'Email Address',
        PASSWORD: 'Password',
        REMEMBER: 'Remember me',
        LOGIN: "Login",
        REGISTER: "Sign in",
        YOURNAME: "Your Name",
        YOUREMAIL: "Your Email",
        USERNAME: "User Name",
        CONFIRMPASSWORD: "Retype Password",
        ENTERYOURNAME: "Enter your name",
        ENTERYOUREMAIL: "Enter your email",
        ENTERYOURUSERNAME: "Enter your Username",
        ENTERYOURPASSWORD: "Enter your Password",
        RETYPEYOURPASSWORD: "Retype your Password",
        USERLOGEDIN: "· User Loged In",
        SOMETHINGWENTBAD: "· Something Went Bad",
        USERREGISTERED: "· User Registered",
        EMAILNOTCONFIRMED: "· User email is not confirmed",
        USERNOTFOUD: "· User not found"
    };

    var translationes = {
        LOGINTITLE: 'Identifícate',
        EMAILADDRESS: 'Correo Electronico',
        PASSWORD: 'Contraseña',
        REMEMBER: 'Recuerdame',
        LOGIN: "Continuar",
        REGISTER: "Registrate",
        YOURNAME: "Tu nombre",
        YOUREMAIL: "Tu email",
        USERNAME: "Nombre de Usuario",
        CONFIRMPASSWORD: "Confirmar Contraseña",
        ENTERYOURNAME: "Introduce tu nombre",
        ENTERYOUREMAIL: "Introduce tu email",
        ENTERYOURUSERNAME: "Introduce tu usuario",
        ENTERYOURPASSWORD: "Introduce tu contraseña",
        RETYPEYOURPASSWORD: "Vuelve a introducir tu contraseña",
        USERLOGEDIN: "· Usuario Logeado",
        SOMETHINGWENTBAD: "· Algo ha funcionado mal",
        USERREGISTERED: "· Usuario registrado",
        EMAILNOTCONFIRMED: "· El usuario no ha confirmado el email",
        USERNOTFOUD: "· Ningun usuario coincide"
    }

    $translateProvider
        .translations('en', translationsen)
        .translations('es', translationes)
        .preferredLanguage('es');
}]);