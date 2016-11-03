(function () {
    'use strict';
    angular.module('eliteApp').controller('leagueCtrl', ['$state','eliteApi',leagueCtrl]);

    function leagueCtrl($state,eliteApi) {
        var vm = this;

        var league = eliteApi.getLeague();
        vm.league = league;

        vm.selectLeague = function (id) {
            //direct us to the app/teams.html
            $state.go("app.teams", {id:2});
        };
    };

}());