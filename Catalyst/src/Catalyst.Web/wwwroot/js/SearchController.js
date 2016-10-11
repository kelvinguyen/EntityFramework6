/*SearchController.js*/
(function () {
    "use strict";
    var initialLoad = true;
    //adding the controller to module
    angular.module("app-search")
            .controller("searchController", searchController);

    function searchController($http,$scope)
    {

        $scope.reloadData = function () {
            var vm = this;
            
            //define people object
            if (initialLoad)
            {
                $scope.people = [];
            }
           
            // retrieve data from search box and set name as property
            $scope.newSearch = {};

            //retrieve data
            
            $http.get("/api/search").then(successFunc, failFunc);
               
            function successFunc(response) {
                var person = response.data;
                if (initialLoad) {
                    $scope.people = person;
                    initialLoad = false;
                }
                else {
                    initialLoad = !initialLoad;
                }
            }

            function failFunc() {
                alert("Fail to retrieve data");
            }
           
            $scope.kelvin = function () {
                var name = $scope.newSearch.username;
                var tempPeople = $scope.people;
                for (var i = 0; i < tempPeople.length ; i++) {
                    var fullname = tempPeople[i].fullName;
                    if (fullname.indexOf(name) == -1) {
                        $scope.people.splice(i, 1);
                        i--;
                    }
                }
              
                $scope.reloadData();
                
            }
            
        }
       
        $scope.reloadData();
       
    }
   


})();
