(function () {
    'use strict';

    angular.module('ticketApp').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'TicketCtrl',
                controllerAs: 'vm',
                templateUrl: 'app/ticket/_ticket.html'
            })
        .when('/admin', {
            controller: 'AdminCtrl',
            controllerAs: 'vm',
            templateUrl: 'app/admin/_admin.html'
        })
    });
})();
