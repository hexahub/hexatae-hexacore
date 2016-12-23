(function () {
    'use strict';

    angular.module('ticketApp').controller('AdminCtrl', AdminCtrl);

    AdminCtrl.$inject = ['$scope', '$rootScope', '$location', '$loginService', '$ticketService'];

    function AdminCtrl($scope, $rootScope, $location, $loginService, $ticketService) {
        var vm = this;

        vm.login = login;
        vm.logout = logout;
        
        vm.token = localStorage.getItem('suporteHexaToken');

        function login() {
            toastr["info"]("Autenticando usuário, por favor aguarde.");
            $loginService.login($scope.email, $scope.password)
                .success(function (data, status) {
                    toastr["success"]("Seja bem vindo " + $scope.email);
                    $rootScope.user = {
                        name: $scope.email,
                        email: $scope.email,
                        access_token: data.access_token
                    };
                    localStorage.setItem('suporteHexaToken', $rootScope.user.access_token)
                    location.reload();
                })
                .error(function (data, status) {
                    toastr["error"]("Não foi possível realizar seu login!");
                });
        }

        function logout() {
            localStorage.removeItem("suporteHexaToken");
            $rootScope.user = null;
            
            location.reload();
            toastr["success"]("Logout realizado com sucesso!");
        }

        $('#modalNovaEmpresa').on('shown.bs.modal', function () {
            $('#NomeEmpresa').focus()
        })

    }
})();