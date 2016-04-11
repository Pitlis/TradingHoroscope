angular.module('app').config(configureStates);
configureStates.$inject = ['$stateProvider'];
function configureStates($stateProvider) {
    var states = getStates();
    states.forEach(function (state) {
        $stateProvider.state(state.state, state.config);
    });
}
function getStates() {
    return [
        {
            state: 'app',
            config: {
                url: '/',
                templateUrl: 'app.html',
                controller: 'AppController',
                controllerAs: 'vm',
                title: 'app',
            }
        }
    ];
}
angular.module('app').run(['$rootScope', '$http', function (rootScope, http) { return new appRun(rootScope, http); }]);
var appRun = (function () {
    function appRun(rootScope, http) {
        this.rootScope = rootScope;
        this.http = http;
        rootScope.$on("$stateChangeError", console.log.bind(console));
        http.defaults.withCredentials = true;
    }
    appRun.$inject = ['$rootScope'];
    return appRun;
}());
;angular.module('templates-dist', []);

