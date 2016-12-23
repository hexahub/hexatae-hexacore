angular.module('ticketApp').factory('$empresaService', function ($http) {
    return {
        api_url: 'http://hexacoreticketsapi.azurewebsites.net',

        insertEmpresa: function (empresa) {
            var config = {
                headers: {
                    "Authorization": "Bearer " + localStorage.getItem('suporteHexaToken'),
                    "Content-Type": "application/json"
                }
            };
            return $http.post(this.api_url + '/api/empresa', JSON.stringify(empresa), config);
        },

        getEmpresas: function () {
            var config = {
                headers: {
                    "Authorization": "Bearer " + localStorage.getItem('suporteHexaToken'),
                    "Content-Type": "application/json"
                }
            };
            return $http.get(this.api_url + '/api/empresa', config);
        }

    };
});