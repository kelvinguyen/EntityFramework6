(function () {
    'use strict';
    angular.module('eliteApp').controller('locationCtrl', ['eliteApi',locationCtrl]);
    
    function locationCtrl(eliteApi) {
        var vm = this;

        var data = eliteApi.getLeagueData();
        vm.location = data.location;

    };

}());