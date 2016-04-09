angular.module('app').run(['$rootScope', '$http', (rootScope, http) => new appRun(rootScope, http)]);

class appRun {

    public static $inject = ['$rootScope'];

    public constructor(private rootScope: ng.IRootScopeService, private http: ng.IHttpService) {
        rootScope.$on("$stateChangeError", console.log.bind(console));
        http.defaults.withCredentials = true;
    }
}