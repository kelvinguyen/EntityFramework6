(function () {
    'use strict';
    angular
        .module('eliteApp')
        .controller('standinCtrl', ['eliteApi', standingCtrl]);

    function standingCtrl(elitApi) {
        var vm = this;
    };

}());