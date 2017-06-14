//appController.js

(function ()
{
    "use strict";

    //Get existing module and add controller to it
    angular.module("app-it1").controller("aboutController", aboutController);

    function aboutController() {
        var vm = this;

        vm.name = "Testing";

        vm.offices = [
            { location:"location 1", contactNo: "012345678910" },
            { location:"location 2", contactNo: "123456789010" }
        ];

        vm.newLocation = {};

        vm.addLocation = function () {
            vm.offices.push(vm.newLocation);
            vm.newLocation = {};
        };
    };

})();