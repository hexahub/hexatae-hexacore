(function () {
    'use strict';

    angular.module('ticketApp').controller('TicketCtrl', TicketCtrl);

    TicketCtrl.$inject = ['$scope', '$ticketService'];

    function TicketCtrl($scope, $ticketService) {

        var vm = this;

        reset();

        function reset() {
            $scope.ticket = {
                TipoTicket: "1",
                NomeContato: "",
                EmpresaId: "",
                Email: "",
                Titulo: "",
                Descricao: ""
            };
        }

        $scope.TipoTicket = [];
        $scope.tickets = [];
        vm.carregarTickets = carregarTickets;
        vm.token = localStorage.getItem('suporteHexaToken');
        $scope.enviando = false;
        $scope.carregandoTickets = false;

        if (vm.token != null && vm.token != '')
            carregarTickets();

        //Configuration
        $scope.TipoTicket.configs = [
          {
              'name': 'Dúvida',
              'value': '1'
          },
          {
              'name': 'Sugestão',
              'value': '2'
          },
          {
              'name': 'Reclamação',
              'value': '3'
          },
          {
              'name': 'Correção de erro',
              'value': '4'
          },
          {
              'name': 'Solicitação de melhoria',
              'value': '5'
          },
          {
              'name': 'Solicitação de nova funcionalidade',
              'value': '6'
          }
        ];

        $scope.enviar = function () {
            toastr["info"]("Enviando Ticket");
            $scope.enviando = true;
            $ticketService.insertTicket($scope.ticket)
                .success(function (data, status) {
                    toastr['success']("Ticket enviado com sucesso!");
                    reset();
                    $scope.enviando = false;
                })
                .error(function (data, status) {
                    toastr['error']("Ops! Houve algum erro durante o envio!");
                    $scope.enviando = false;
                });
        };

        function carregarTickets() {
            $scope.carregandoTickets = true;
            $ticketService.getTickets().success(function (data) {
                toastr["success"]("Tickets carregados com sucesso.");
                $scope.tickets = data;
                $scope.carregandoTickets = false;
            }).catch(function () {
                toastr["error"]("Erro ao carregar tickets.");
                $scope.carregandoTickets = false;
            });
        };

    }
})();
