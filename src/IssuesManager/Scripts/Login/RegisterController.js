App.controller("registerController", ["$scope", "UserAPI", "$translate", function ($scope, UserAPI, $translate) {
    $scope.ResponseData = { Result: true }
    $scope.ShowRegisterForm = true;
    $scope.LoginHasSuccess = function () { return !$scope.ResponseData.status === 200; };
    $scope.LoginHasError = function () { return ($scope.ResponseData.status === 400 || $scope.ResponseData.status === 500); };
    $scope.loading = false;
    $scope.RegisterClick = function () {

        $scope.loading = true;
        $scope.ShowRegisterForm = false;
        $scope.Message = "";
        UserAPI.Register($scope.Name, $scope.Email, $scope.UserName, $scope.Password, $scope.RePassword, function (Result) {
            $scope.ResponseData = Result;

            $scope.ShowRegisterForm = true;
            $scope.loading = false;
            $translate(Result.data.success).then(function (translation) {
                $scope.Message = translation;
            });

        }, function (Result) {
            $scope.ResponseData = Result;
            $scope.ShowRegisterForm = true;
            $scope.loading = false;
            $translate(Result.data.error).then(function (translation) {
                $scope.Message = translation;
            });
        });
    };
}]);
