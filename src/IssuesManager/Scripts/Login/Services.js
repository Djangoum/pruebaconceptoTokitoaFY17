angular.module("DataServices", ["constants"])
    .service("UserAPI", ["UserController", "$http", function (UserController, $http) {
        this.Login = function (UserName, Password, Remember, ResultCallback, ErrorCallBack) {
            var Result = {};

            $http.post(UserController + '/Login', { UserName: UserName, Password: Password, Remember: Remember })
                .then(function (response) {

                    ResultCallback(response);
                },
                function (response) {

                    ErrorCallBack(response);
                });
        };

        this.Register = function (Name, Email, UserName, Password, RePassword, ResultCallback, ErrorCallBack) {
            $http.post(UserController + '/Register' , { Name: Name, Email: Email, UserName: UserName, Password: Password, RePassword: RePassword })
            .then(function (response) {

                ResultCallback(response);
            },
            function (response) {

                ErrorCallBack(response);
            });
        }
    }]);