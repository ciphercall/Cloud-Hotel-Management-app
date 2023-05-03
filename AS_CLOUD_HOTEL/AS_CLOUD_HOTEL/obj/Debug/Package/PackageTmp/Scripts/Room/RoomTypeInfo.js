var RoomTypeApp = angular.module("RoomTypeApp", ['ui.bootstrap']);

RoomTypeApp.controller("ApiRoomController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;


    // Inital Grid view load 
    var compid = $('#txtcompid').val();
    $http.get('/api/ApiRoom/GetRoomTypeInfo/', {
        params: {
            Compid: compid
        }
    }).success(function (data) {
        if (data[0].count == 1) {
            $scope.RoomeTypeData = null;
        } else {
            $scope.RoomeTypeData = data;
        }
        $scope.loading = false;
    });




    $scope.toggleEdit = function () {
        this.testitem.editMode = !this.testitem.editMode;
    };



    $scope.toggleEdit_Cancel = function () {
        this.testitem.editMode = !this.testitem.editMode;
        //Grid view load 
        var compid1 = $('#txtcompid').val();
        $http.get('/api/ApiRoom/GetRoomTypeInfo/', {
            params: {
                Compid: compid1,
            }
        }).success(function (data) {
            $scope.RoomeTypeData = data;
            $scope.loading = false;
        });
    };





    //Add grid level data
    $scope.addrow = function (event) {
        $scope.loading = false;
        event.preventDefault();

        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#RoomTypeNameID').val("");
            $('#RateBDTID').val("0");
            $('#RateUSDID').val("0");
            alert("Permission Denied!!");
        }
        else {
            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();
            this.newChild.RTPNM = $('#RoomTypeNameID').val();
            this.newChild.RATEBDT = $('#RateBDTID').val();
            this.newChild.RATEUSD = $('#RateUSDID').val();
            this.newChild.STATUS = $('#statusID').val();
            if (this.newChild.RTPNM != "") {
                $http.post('/api/ApiRoom/AddData', this.newChild).success(function (data, status, headers, config) {

                    //Grid view load 
                    var compid2 = $('#txtcompid').val();
                    $http.get('/api/ApiRoom/GetRoomTypeInfo/', {
                        params: {
                            Compid: compid2,
                        }
                    }).success(function (data) {
                        $scope.RoomeTypeData = data;
                        $scope.loading = false;
                    });


                    if (data.RTPID != 0) {
                        $('#RoomTypeNameID').val("");
                        $('#RateBDTID').val("0");
                        $('#RateUSDID').val("0");
                        alert("Create Successfully !!");
                        //$scope.RoomeTypeData.push({ ID: data.ID, MCATID: data.MCATID, MCATNM: data.MCATNM });
                    } else {
                        $('#RoomTypeNameID').val("");
                        $('#RateBDTID').val("0");
                        $('#RateUSDID').val("0");
                        alert("Duplicate name will not create!");
                    }

                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                    $scope.loading = false;
                });

            }
            else {
                $('#RoomTypeNameID').val("");
                $('#RateBDTID').val("0");
                $('#RateUSDID').val("0");
                alert("Please input Room type name field !!");
            }
        }
    };







    //Update to grid level data (save a record after edit)
    $scope.update = function () {
        $scope.loading = true;
        var frien = this.testitem;

        this.testitem.COMPID = $('#txtcompid').val();
        this.testitem.INSUSERID = $('#txtInsertUserid').val();
        this.testitem.INSLTUDE = $('#latlon').val();
        //this.testitem.STATUS = $('#gridStatusID option:selected').val();
        var Update = $('#txt_Updateid').val();

        if (Update == "I") {
            alert("Permission Denied!!");
            frien.editMode = false;

            //Grid view load 
            var compid3 = $('#txtcompid').val();
            $http.get('/api/ApiRoom/GetRoomTypeInfo/', {
                params: {
                    Compid: compid3,
                }
            }).success(function (data) {
                $scope.RoomeTypeData = data;
            });

            $scope.loading = false;
        }
        else {
            $http.post('/api/ApiRoom/UpdateData', this.testitem).success(function (data) {
                alert("Saved Successfully!!");
                frien.editMode = false;

                //Grid view load 
                var compid4 = $('#txtcompid').val();
                $http.get('/api/ApiRoom/GetRoomTypeInfo/', {
                    params: {
                        Compid: compid4,
                    }
                }).success(function (data) {
                    $scope.RoomeTypeData = data;
                });

                $scope.loading = false;

            }).error(function (data) {
                $scope.error = "An Error has occured while Saving Friend! " + data;
                $scope.loading = false;

            });
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

            $http.post('/api/ApiRoom/DeleteData', this.testitem).success(function (data) {

                var getChildDataForDeleteMasterCategory = data.GetChildDataForDeleteMasterCategory;
                if (getChildDataForDeleteMasterCategory == 1) {
                    $scope.loading = false;
                    alert("Please firstly delete category wise child data first!!");
                }
                else {
                    $.each($scope.RoomeTypeData, function (i) {
                        if ($scope.RoomeTypeData[i].ID === id) {
                            $scope.RoomeTypeData.splice(i, 1);
                            return false;
                        }
                    });
                    $scope.loading = false;
                    alert("Delete Successfully!!");
                }
            }).error(function (data) {
                $scope.error = "An Error has occured while delete posts! " + data;
                $scope.loading = false;
            });
        }
    };


});