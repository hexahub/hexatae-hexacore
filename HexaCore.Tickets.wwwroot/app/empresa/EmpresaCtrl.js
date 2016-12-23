(function () {
    'use strict';

    angular.module('ticketApp').controller('EmpresaCtrl', EmpresaCtrl);

    EmpresaCtrl.$inject = ['$scope', '$empresaService'];

    function EmpresaCtrl($scope, $empresaService) {

        var vm = this;

        reset();

        function reset() {
            $scope.empresa = {
                Nome: ""
            };
        }

        $scope.empresas = [];
        carregarEmpresas();

        $scope.novaEmpresa = function () {
            toastr["info"]("Salvando Empresa");
            $empresaService.insertEmpresa($scope.empresa)
                .success(function (data, status) {
                    toastr['success']("Empresa salva com sucesso!");
                    reset();
                    carregarEmpresas();
                })
                .error(function (data, status) {
                    toastr['error']("Ops! Houve algum erro durante o envio!");
                });
        };

        function carregarEmpresas() {
            $empresaService.getEmpresas().success(function (data) {
                toastr["success"]("Empresas carregadas com sucesso.");
                $scope.empresas = data;
            }).catch(function () {
                toastr["error"]("Erro ao carregar empresas.");
            });
        };

    }
})();
