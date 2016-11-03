//create a services
(function () {
    'use strict';
    angular.module('eliteApp').factory('eliteApi', [eliteApi]);

    function eliteApi() {
        var leagues = JSON.parse('[{"userId": 1,"id": 1},{"userId": 2,"id": 2}]');
        var leaguesData = JSON.parse('{"location": "123 redwood","idData": 1,"teams":"Team USA"}');

        function getLeague() {
            return leagues;
        };

        function getLeagueData() {
            return leaguesData;
        };

        return {
            getLeague: getLeague,
            getLeagueData : getLeagueData
        };
    };

}());