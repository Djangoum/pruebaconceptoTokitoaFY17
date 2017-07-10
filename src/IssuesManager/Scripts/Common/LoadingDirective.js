angular.module('loading', [])
    .directive('loading', [function () {
        return {
            restrict: 'E',
            replace: true,
            template: '<div class="loading" ng-show="ShowLoadingAnimation"><img class="center-block" src="/images/89.gif" width="20" height="20" /></div>',
            link: function (scope, element, attr) {
                scope.$watch('loading', function (val) {
                    if (val)
                        scope.ShowLoadingAnimation = true;
                    else
                        scope.ShowLoadingAnimation = false;
                });
            }
        }
    }]);