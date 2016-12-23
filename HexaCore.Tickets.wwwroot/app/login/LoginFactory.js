angular.module('ticketApp').factory('$loginService', function ($http) {
    return {
        api_url: 'http://hexacoreticketsapi.azurewebsites.net',
        login: function (username, password) {
            var config = {
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                }
            };
            var data = "grant_type=password&username=" + username + '&password=' + password;
            return $http.post(this.api_url + '/api/security/token', data, config);
        },

    };
});