var token = $('input[name="__RequestVerificationToken"]').val();
var headers = {};
headers['__RequestVerificationToken'] = token;

var app = angular.module('appServices', []);

app.factory('pageController', ['$http', function ($http) {    
    var factory = {};
    factory.createController = function (prop) {

        var fac = {};

        //assegno i default
        fac.displayMode = 'list';
        fac.filtri = {};
        fac.current = null;
        fac.records = [];

        fac.filterTable = '';

        fac.rec_x_pagina = 0;
        fac.rec_number = 0;
        fac.page_number = 0;
        fac.rec_pagina = -1;

        fac.nr_pagine_display = 4;

        fac.prop = prop;

        //contenuto
        fac.refresh_page = function (page_number) {            
            fac.filtri.page_number = page_number;
            $http({
                method: 'POST',
                headers: headers,
                url: fac.prop.api_root + '/getContenutoPagina',
                data: fac.filtri
            }).then(function successCallBack(response) {
                fac.filterTable = '';
                fac.records = response.data;
                fac.pag_corrente = page_number;
                fac.rec_pagina = -1;
            }, function errorCallBack(response) {
                fac.prop.message_function('Errore', response.data);
            });
        };

        //paginatore
        fac.refresh = function () {
            $http({
                method: 'POST',
                headers: headers,
                url: fac.prop.api_root + '/getPaginatore',
                data: fac.filtri
            }).then(function successCallBack(response) {
                fac.rec_x_pagina = response.data.rec_x_pagina;
                fac.rec_number = response.data.rec_number;
                fac.pag_number = response.data.pag_number;
                fac.refresh_page(0);
            }, function errorCallBack(response) {
                fac.prop.message_function('Errore', response.data);
            });
        };

        //record_sucessivo
        fac.next_record = function () {

            fac.rec_pagina++;
            if (fac.rec_pagina >= fac.records.length) {
                fac.rec_pagina = 0;
            }
            fac.prop.select_row_call_back(fac.rec_pagina + 1);
        };

        //record precedente
        fac.previous_record = function () {

            fac.rec_pagina--;
            if (fac.rec_pagina < 0) {
                fac.rec_pagina = fac.records.length - 1;
            }
            fac.prop.select_row_call_back(fac.rec_pagina + 1);
        };

        //numero pagina
        fac.nr_pagina_paginatore = function (indice) {
            if (indice + 1 > fac.pag_number) {
                return -1;
            } else if (fac.pag_corrente + 1 < fac.nr_pagine_display) {
                return indice;
            } else {
                return fac.pag_corrente + indice - fac.nr_pagine_display + 1;
            }
        };

        //ordinamento
        fac.sortData = function (column) {
            fac.reverseSort = (fac.sortColumn = column) ? !fac.reverseSort : false;
            fac.sortColumn = column;
        }

        //classe verso ordinamento
        fac.getSortClass = function (column) {
            if (fac.sortColumn == column) {
                return fac.reverseSort ? 'fa fa-sort-desc' : 'fa fa-sort-asc';
            }
            return 'fa fa-sort text-secondary';
        }

        //inserimento
        fac.create = function () {
            fac.nuovo = true;
            fac.tipoAzione = 'Inserimento';
            fac.displayMode = 'edit';
            fac.current = {};

            if (typeof (prop.exit_edit) !== 'undefined') {
                prop.exit_new();
            }
        }       

        //aggiornamento
        fac.edit = function (item) {
            fac.nuovo = false;
            fac.tipoAzione = 'Modifica';
            fac.displayMode = 'edit';
            fac.current = item;
        }

        //annulla inserimento-aggiornamento
        fac.cancelEdit = function () {
            fac.current = {};
            fac.displayMode = 'list';
            fac.refresh_page(fac.filtri.page_number);
        }

        //salva in inserimento o in aggiornamento
        fac.saveEdit = function () {
            if (fac.nuovo) {
                fac.insert();
            } else {
                fac.update();
            }
        }

        //inserimento
        fac.insert = function () {
            $http({
                method: 'POST',
                headers: headers,
                url: fac.prop.api_root + '/create',
                data: fac.current
            }).then(function successCallBack(response) {
                if (response.data.db_obj_ack === 'OK') {
                    fac.displayMode = "list";
                    fac.refresh_page(fac.filtri.page_number);
                    if (typeof (callback) == 'function') {
                        callback(item);
                    }
                } else {
                    fac.prop.message_function('Errore', response.data.db_obj_message);
                }
            }, function errorCallBack(response) {
                fac.prop.message_function('Errore', response.data);
            });
        }       

        //aggiornamento
        fac.update = function () {
            $http({
                method: 'POST',
                headers: headers,
                url: fac.prop.api_root + '/edit',
                data: fac.current
            }).then(function successCallBack(response) {
                if (response.data.db_obj_ack === 'OK') {
                    fac.displayMode = "list";
                    fac.refresh_page(fac.filtri.page_number);
                    if (typeof (callback) == 'function') {
                        callback(item);
                    }
                } else {
                    fac.prop.message_function('Errore', response.data.db_obj_message);
                }
            }, function errorCallBack(response) {
                fac.prop.message_function('Errore', response.data);
            });
        }

        //eliminazione
        fac.deleteItem = function (item) {
            swal({
                title: 'Intendi procedere?',
                text: "Questa azione non può essere annullata!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonClass: "btn btn-primary",
                cancelButtonClass: "btn",                
                confirmButtonText: 'Si, elimina!',
                cancelButtonText: 'Annulla'
            }).then(function (result) {
                if (result) {
                    $http({
                        method: 'POST',
                        headers: headers,
                        url: fac.prop.api_root + '/delete',
                        data: item
                    }).then(function successCallBack(response) {
                        if (response.data.db_obj_ack === 'OK') {
                            swal(
                                'Eliminato!',
                                'Il record selezionato è stato eliminato.',
                                'success'
                            )
                            fac.displayMode = "list";
                            fac.refresh_page(fac.filtri.page_number);                            
                        } else {
                            fac.prop.message_function('Errore', response.data.db_obj_message);
                        }
                    }, function errorCallBack(response) {
                        fac.prop.message_function('Errore', response.data);
                    });
                }
            })
        }

        return fac;
    };
    return factory;
}]);

app.directive('pageControllerPag', ['$http', function ($http) {
    return {
        restrict: 'AE',
        replace: 'true',
        templateUrl: '/Vendors/angular/pageControllerPag.tpl.html',
        scope: {
            tc:'=pageController'
        }
    };
}]);