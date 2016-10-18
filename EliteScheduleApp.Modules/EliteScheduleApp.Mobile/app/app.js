/// <reference path="../lib/ionic/js/ionic-angular.min.js" />
/// <reference path="../lib/ionic/js/angular/angular.min.js" />
/// <reference path="../lib/ionic/js/ionic.min.js" />
/// <reference path="../lib/ionic/js/ionic.bundle.min.js" />


angular.module("eliteApp", ["ionic"])

.run(function ($ionicPlatform) {
    $ionicPlatform.ready(function () {
        // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
        // for form inputs)
        if (window.cordova && window.cordova.plugins.Keyboard) {
            cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            cordova.plugins.Keyboard.disableScroll(true);

        }
        if (window.StatusBar) {
            // org.apache.cordova.statusbar required
            StatusBar.styleDefault();
        }
    });
})

.config(function ($stateProvider,$urlRouterProvider) {

    $stateProvider
        // home master layout
        .state('home', {
            url: "/home",
            abstract : true,
            templateUrl: "app/home/home.html"
        })

        //child page of home
        .state('home.leagues', {
            url: "/leagues",
            views: {
                "tab-leagues": {
                    templateUrl : "app/home/leagues.html"
                }
            }
        })


        .state('home.myteams', {
            url: "/myteams",
            views: {
                "tab-myteams": {
                    templateUrl : "app/home/myteams.html"
                }
            }
        })




        //side menu master layout
        .state('app', {
            abstract : true,
            url: "/app",
            templateUrl : "app/layout/menu-layout.html"
        })


        // child page of side-menu
        .state('app.teams', {
            url: '/teams',
            views: {
                "mainContent": {
                    templateUrl : 'app/teams/teams.html'
                }
            }
        })

        .state('app.teamDetails', {
            url: '/teams/:id',
            views: {
                'mainContent': {
                    templateUrl : 'app/teams/teamDetails.html'
                }
            }
        })

        .state('app.game', {
            url: '/game/:id',
            views: {
                'mainContent': {
                    templateUrl : 'app/game/game.html'
                }
            }
        })
        
        .state('app.standing', {
             url: '/standing',
             views: {
                 'mainContent': {
                     templateUrl: 'app/standing/standing.html'
                 }
             }
         })

        .state('app.locations', {
             url: '/locations',
             views: {
                 'mainContent': {
                     templateUrl: 'app/locations/locations.html'
                 }
             }
        })

        .state('app.rules', {
             url: '/rules',
             views: {
                 'mainContent': {
                     templateUrl: 'app/rules/rules.html'
                 }
             }
         });

    $urlRouterProvider.otherwise('/app/teams');
});