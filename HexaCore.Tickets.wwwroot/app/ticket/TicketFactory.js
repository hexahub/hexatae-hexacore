angular.module('ticketApp').factory('$ticketService', function ($http) {
    return {
        api_url: 'http://hexacoreticketsapi.azurewebsites.net',

        insertTicket: function (ticket) {
            var config = {
                headers: {
                    "Content-Type": "application/json"
                }
            };
            return $http.post(this.api_url + '/api/ticket', JSON.stringify(ticket), config);
        },

        getTickets: function () {
            var config = {
                headers: {
                    "Authorization": "Bearer " + localStorage.getItem('suporteHexaToken'),
                    "Content-Type": "application/json"
                }
            };
            return $http.get(this.api_url + '/api/ticket', config);
        }

    };
});