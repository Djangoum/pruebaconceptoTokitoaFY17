App.controller("loginController", ["$scope", "UserAPI", "$window", "$translate", function ($scope, UserAPI, $window, $translate) {
    $scope.ResponseData = { Result: true }
    $scope.ShowLoginForm = true;
    $scope.loading = false;
    $scope.LoginHasSuccess = function () { return !$scope.ResponseData.status === 200; };
    $scope.LoginHasError = function () { return ($scope.ResponseData.status === 400 || $scope.ResponseData.status === 500); };

    $scope.LoginClick = function () {

        $scope.ShowLoginForm = false;
        $scope.loading = true;

        UserAPI.Login($scope.UserName, $scope.password, $scope.remember, function (ResultData) {
            $scope.ResponseData = ResultData;
            $translate(ResultData.success).then(function (translation) {
                $scope.Message = translation;
            });
            $window.location.href = "/Landing";
          
        }, function (ResultData) {
            $scope.ResponseData = ResultData;
            $scope.loading = false;
            $scope.ShowLoginForm = true;

            $translate(ResultData.data.error).then(function (translation) {
                $scope.Message = translation;
            });
            $scope.remember = false;
        });
    }
}]);

