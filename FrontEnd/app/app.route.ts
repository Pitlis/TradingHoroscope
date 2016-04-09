angular.module('app').config(configureStates);

configureStates.$inject = ['$stateProvider'];

function configureStates(
    $stateProvider: ng.ui.IStateProvider) {

    let states = getStates();
    states.forEach(function(state) {
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