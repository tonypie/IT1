//experienceController.js

(function () {
    "use strict";

    angular.module("app-it1").
        controller("experienceController", ["$http", experienceController]);

    function experienceController($http) {
        var vm = this;

        vm.addNew = false;
        vm.experiences = [];
        vm.newExperience = {};
        vm.errorMessage = "";

        vm.isBusy = true;
        //Get experience data
        $http.get("/api/Experiences")
            .then(function (response) {
                //as part of success copy to vm
                angular.copy(response.data, vm.experiences);
            }
            , function (error) {
                vm.errorMessage("There was a problem retrieving data!" + error.errorMessage);
            })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.addExperience = function ()
        {
            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/Experiences", vm.newExperience)
                .then(function (response) {
                    //as part of success copy to vm
                    vm.experiences.push(response.data);
                    vm.addNew = false;
                    vm.newExperience = {};
                }
                , function (error) {
                    vm.errorMessage("Failed to save new Experience!" + error.errorMessage);
                })
                .finally(function () {
                    vm.isBusy = false;
                });
        }

        vm.AddExperienceToggle = function () {
            vm.addNew = !vm.addNew;
        };
    };
})();