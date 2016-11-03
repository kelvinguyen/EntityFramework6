(function () {
    angular
        .module('eliteApp')
        .controller('teamCtrl', ['eliteApi',teamCtrl]);

    function teamCtrl(eliteApi) { 
        var vm = this;

        var data = eliteApi.getLeagueData();

        vm.teams = data.teams;
    };


}());

