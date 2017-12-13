var app = angular.module('appModules', []);

app.directive('ngOnEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngOnEnter);
                });

                event.preventDefault();
            }
        });
    };
});

app.directive('capitalize', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, modelCtrl) {
            var capitalize = function (inputValue) {
                if (inputValue === undefined) inputValue = '';
                var capitalized = inputValue.toUpperCase();
                if (capitalized !== inputValue) {
                    modelCtrl.$setViewValue(capitalized);
                    modelCtrl.$render();
                }
                return capitalized;
            };
            modelCtrl.$parsers.push(capitalize);
            capitalize(scope[attrs.ngModel]); // capitalize initial value
        }
    };
});

app.directive('selectpicker', function () {
    return {       
        link: function (scope, element, attrs) {
            element.selectpicker({
                liveSearch: true,
                style: 'btn-select',
                size: 4
            }).ajaxSelectPicker({
                ajax: {
                    url: attrs['selectpicker'],                    
                    data: function () {
                        var params = {
                            query: '{{{q}}}'
                        };                        
                        return params;
                    }
                },
                locale: {
                    emptyTitle: 'Cerca...',
                    searchPlaceholder: element.find('info'),
                },
                preprocessData: function (data) {
                    var records = [];
                    if (data.length > 0) {
                        var len = data.length;
                        for (var i = 0; i < len; i++) {
                            var curr = data[i];
                            records.push(
                                {
                                    'value': curr.ID,
                                    'text': curr.Text,                                    
                                    'disabled': false
                                }
                            );
                        }
                    }
                    return records;
                },
                preserveSelected: false
            });
        }
    };
});




