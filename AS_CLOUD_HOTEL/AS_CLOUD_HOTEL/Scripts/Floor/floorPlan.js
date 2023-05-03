var FloorPlanApp = angular.module("FloorPlanApp", ['ui.bootstrap']);

FloorPlanApp.controller("ApiFloorPlanController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;


    $scope.search = function (event) {

        $scope.loading = true;
        event.preventDefault();

        var compid = $('#txtcompid').val();
        var floorID = $('#ddlFloorID option:selected').val();

        $http.get('/api/ApiFloorPlan/GetFloorPlanData/', {
            params: {
                Compid: compid,
                floorid: floorID,
            }
        }).success(function (data) {
            if (data[0].count == 1) {
                $scope.FloorPlanData = null;
            } else {
                $scope.FloorPlanData = data;
            }
            $scope.loading = false;
        });

    };




    $scope.toggleEdit = function () {
        this.testitem.editMode = !this.testitem.editMode;
    };



    $scope.toggleEdit_Cancel = function () {
        this.testitem.editMode = !this.testitem.editMode;

        //Grid view load 
        var compid = $('#txtcompid').val();
        var floorID = $('#ddlFloorID option:selected').val();

        $http.get('/api/ApiFloorPlan/GetFloorPlanData/', {
            params: {
                Compid: compid,
                floorid: floorID,
            }
        }).success(function (data) {
            $scope.FloorPlanData = data;
            $scope.loading = false;
        });
    };




    //Add grid level data
    $scope.addrow = function (event) {
        $scope.loading = false;
        event.preventDefault();

        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#RoomTypesID').val("-SELECT-");
            $('#RoomNoID').val("-SELECT-");
            $('#remarksID').val("");
            alert("Permission Denied!!");
        }
        else {

            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();
            this.newChild.FLOORID = $('#ddlFloorID option:selected').val();
            this.newChild.RTPID = $('#RoomTypesID option:selected').val();
            this.newChild.ROOMNO = $('#RoomNoID option:selected').val();
            this.newChild.REMARKS = $('#remarksID').val();

            
            if (this.newChild.FLOORID != "" && this.newChild.RTPID != "" && this.newChild.ROOMNO != "" && this.newChild.FLOORID != 0 && this.newChild.RTPID != 0 && this.newChild.ROOMNO != 0) {
                $http.post('/api/ApiFloorPlan/AddData', this.newChild).success(function (data, status, headers, config) {

                    //Grid view load 
                    var compid = $('#txtcompid').val();
                    var floorID = $('#ddlFloorID option:selected').val();

                    $http.get('/api/ApiFloorPlan/GetFloorPlanData/', {
                        params: {
                            Compid: compid,
                            floorid: floorID,
                        }
                    }).success(function (data) {
                        $scope.FloorPlanData = data;
                        $scope.loading = false;
                    });


                    if (data.RTPID != 0) {
                        $('#RoomTypesID').val("-SELECT-");
                        $('#RoomNoID').val("-SELECT-");
                        $('#remarksID').val("");
                        alert("Create Successfully !!");
                        //$scope.FloorPlanData.push({ ID: data.ID, MCATID: data.MCATID, MEDIID: data.MEDIID, MEDINM: data.MEDINM, PHARMAID: data.PHARMAID, GHEADID: data.GHEADID });
                    } else {
                        $('#RoomTypesID').val("-SELECT-");
                        $('#RoomNoID').val("-SELECT-");
                        $('#remarksID').val("");
                        alert("Duplicate name will not create!");
                    }

                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                    $scope.loading = false;
                });

            }
            else {
                $('#RoomTypesID').val("-SELECT-");
                $('#RoomNoID').val("-SELECT-");
                $('#remarksID').val("");
                alert("Please Select grid level data !!");
            }

        }
    };

    




    //Delete grid level data.
    $scope.deleteItem = function () {
        $scope.loading = true;
        var id = this.testitem.ID;

        var Delete = $('#txt_Deleteid').val();
        if (Delete == "I") {
            alert("Permission Denied!!");
        }
        else {
            this.testitem.COMPID = $('#txtcompid').val();
            this.testitem.INSUSERID = $('#txtInsertUserid').val();
            this.testitem.INSLTUDE = $('#latlon').val();

            $http.post('/api/ApiFloorPlan/DeleteData/', this.testitem).success(function (data) {

                $.each($scope.FloorPlanData, function (i) {
                    if ($scope.FloorPlanData[i].ID === id) {
                        $scope.FloorPlanData.splice(i, 1);
                        return false;
                    }
                });
                $scope.loading = false;
                alert("Delete Successfully!!");

            }).error(function (data) {
                $scope.error = "An Error has occured while delete posts! " + data;
                $scope.loading = false;
            });
        }
    };



});