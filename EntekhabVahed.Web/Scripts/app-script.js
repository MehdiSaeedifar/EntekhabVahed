(function () {


    var app = angular.module("myApp", ['ui.bootstrap', 'unsavedChanges', 'webStorageModule', "smoothScroll", 'ngAnimate']);


    app.controller("MyController", ["$scope", "webStorage", "$http", "$modal", "smoothScroll", function ($scope, webStorage, $http, $modal, smoothScroll) {

        $scope.unitTables = [];
        $scope.tabs = [{ isActive: true }, { isActive: false }, { isActive: false }];
        $scope.submitButton =
        {
            isDisable: false,
            text: "محاسبه برنامه هفتگی واحد‌ها"
        };

        function initData() {


            $scope.lstCoursesName = [];

            $scope.lstTeachersNames = [];

            $scope.lstUnits = [
                {
                    classDateTimes: [{}]
                }
            ];

            $scope.unitConfig = {
                maxUnitNumber: 20,
                minUnitNumber: 10
            };

            $scope.options = {
                saveData: true
            }
        }

        initData();


        var onLoad = function () {
            if (webStorage.has("lstUnits")) {
                $scope.lstUnits = webStorage.get("lstUnits");
                $scope.lstCoursesName = webStorage.get("lstCourseNames");
                $scope.lstTeachersNames = webStorage.get("lstTeacherNames");
                $scope.unitConfig = webStorage.get("unitConfig");
            }
        }
        onLoad();

        $scope.updateCourseNameList = function (courseName) {

            if ($scope.lstCoursesName.length > 0) {

                var isDuplicate = false;

                angular.forEach($scope.lstCoursesName, function (item) {

                    if (courseName == item) {
                        isDuplicate = true;
                    }

                });

                if (!isDuplicate) {
                    $scope.lstCoursesName.push(courseName);
                }

            } else {
                $scope.lstCoursesName.push(courseName);
            }
        }


        $scope.updateTeacherNameList = function (teacherName) {

            if ($scope.lstTeachersNames.length > 0) {

                var isDuplicate = false;

                angular.forEach($scope.lstTeachersNames, function (item) {

                    if (teacherName == item) {
                        isDuplicate = true;
                    }

                });

                if (!isDuplicate) {
                    $scope.lstTeachersNames.push(teacherName);
                }

            } else {
                $scope.lstTeachersNames.push(teacherName);
            }
        }


        $scope.add = function (index, unit) {

            var newUnit = angular.copy(unit);

            newUnit.id = undefined;

            $scope.lstUnits.splice(index + 1, 0, newUnit);

            $scope.updateCourseNameList(unit.courseName);

            $scope.updateTeacherNameList(unit.teacherName);
        }

        $scope.addEmptyUnit = function () {

            $scope.lstUnits.push({ classDateTimes: [{}] });

            $scope.updateCourseNameList($scope.lstUnits[$scope.lstUnits.length - 1].courseName);
            $scope.updateTeacherNameList($scope.lstUnits[$scope.lstUnits.length - 1].teacherName);
        }

        $scope.submitLstUnits = function () {

            $scope.submitButton =
            {
                isDisable: true,
                text: "در حال حساب کتاب هستیم..."
            };

            webStorage.clear();
            if ($scope.options.saveData) {
                webStorage.set("lstUnits", $scope.lstUnits);
                webStorage.set("lstTeacherNames", $scope.lstTeachersNames);
                webStorage.set("lstCourseNames", $scope.lstCoursesName);
                webStorage.set("unitConfig", $scope.unitConfig);
            }

            $http.post("/home/getdata", {
                model: {
                    unitsList: $scope.lstUnits,
                    unitsConfig: $scope.unitConfig
                }
            }).success(function (data) {

                if (data.length > 0) {
                    $scope.unitTables = data;

                    var element = document.getElementById('siteWrapper');
                    smoothScroll(element);
                    $scope.tabs[0].isActive = false;
                    $scope.tabs[1].isActive = false;
                    $scope.tabs[2].isActive = true;
                } else {

                    var modalInstance = $modal.open({
                        animation: true,
                        templateUrl: 'message.html',
                        controller: 'MessageBoxController'
                    });

                }

            }).finally(function () {
                $scope.submitButton =
                {
                    isDisable: false,
                    text: "محاسبه برنامه هفتگی واحد‌ها"
                };
            });



            //console.log($scope.lstUnits);
            //console.log(JSON.stringify($scope.lstUnits));
        }


        $scope.addDateTime = function (index, classDateTimes, classDateTime) {

            classDateTimes.splice(index + 1, 0, angular.copy(classDateTime));
        }

        $scope.removeDateTime = function (index, classDateTimes, classDateTime) {

            for (var i = 0; i < classDateTimes.length; i++) {

                if (classDateTimes[i].$$hashKey == classDateTime.$$hashKey) {
                    classDateTimes.splice(i, 1);
                    return;
                }
            }
        }

        $scope.removeUnit = function (unit) {

            for (var i = 0; i < $scope.lstUnits.length; i++) {

                if ($scope.lstUnits[i].$$hashKey == unit.$$hashKey) {
                    $scope.lstUnits.splice(i, 1);
                    return;
                }
            }
        }

        $scope.removeData = function () {
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'removeData.html',
                controller: 'RemoveDataController',
            });

            modalInstance.result.then(function () {

                initData();

            }, function () {

            });
        };


        $scope.removeHistory = function () {
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'clearHistory.html',
                controller: 'ClearHistoryController',
            });

            modalInstance.result.then(function () {

                webStorage.clear();

            }, function () {

            });
        }


    }]);

    app.controller('RemoveDataController', ["$scope", "$modalInstance", function ($scope, $modalInstance) {


        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

    }]);
    app.controller('ClearHistoryController', ["$scope", "$modalInstance", function ($scope, $modalInstance) {


        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

    }]);
    app.controller('MessageBoxController', ["$scope", "$modalInstance", function ($scope, $modalInstance) {


        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

    }]);





})();