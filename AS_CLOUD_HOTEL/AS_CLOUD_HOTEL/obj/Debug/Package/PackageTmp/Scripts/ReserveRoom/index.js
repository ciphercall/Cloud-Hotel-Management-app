var ReserveRoomApp = angular.module("ReserveRoomApp", ['ui.bootstrap']);

ReserveRoomApp.controller("ApiReserveRoomController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;
  

    $scope.search = function (event) {

        $scope.loading = true;
        event.preventDefault();

        var compid = $('#txtcompid').val();
        var reserveid = $('#txt_RESVID option:selected').val();

        $http.get('/api/ApiReserveRoom/GetReserveRoomData/', {
            params: {
                companyID: compid,
                reserveID: reserveid,
            }
        }).success(function (data) {
            if (data[0].count == 1) {
                $scope.ReserveRoomData = null;
            } else {
                $scope.ReserveRoomData = data;
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
        var reserveid = $('#txt_RESVID option:selected').val();

        $http.get('/api/ApiReserveRoom/GetReserveRoomData/', {
            params: {
                companyID: compid,
                reserveID: reserveid,
            }
        }).success(function (data) {
            $scope.ReserveRoomData = data;
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
            $('#roomrTo').val("");
            $('#disctp').val("");
            $('#disCrt').val("");
            $('#roomrTs').val("");
            $('#roomQty').val("");
            $('#remarksID').val("");
            alert("Permission Denied!!");
        }
        else {

            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();

            this.newChild.RESVID = $('#txt_RESVID option:selected').val();
            this.newChild.RTPID = $('#RoomTypesID option:selected').val();
            this.newChild.ROOMRTO = $('#roomrTo').val();
            this.newChild.DISCTP = $('#disctp').val();
            this.newChild.DISCRT = $('#disCrt').val();
            this.newChild.ROOMRTS = $('#roomrTs').val();
            this.newChild.ROOMQTY = $('#roomQty').val();
            this.newChild.REMARKS = $('#remarksID').val();


            if (this.newChild.RESVID != "" && this.newChild.RTPID != "" && this.newChild.RESVID != 0 && this.newChild.RTPID != 0) {
                $http.post('/api/ApiReserveRoom/AddData', this.newChild).success(function (data, status, headers, config) {

                    //Grid view load 
                    var compid = $('#txtcompid').val();
                    var reserveid = $('#txt_RESVID option:selected').val();

                    $http.get('/api/ApiReserveRoom/GetReserveRoomData/', {
                        params: {
                            companyID: compid,
                            reserveID: reserveid,
                        }
                    }).success(function (data) {
                        $scope.ReserveRoomData = data;
                        $scope.loading = false;
                    });

                    if (data.RTPID != 0) {
                        $('#RoomTypesID').val("-SELECT-");
                        $('#roomrTo').val("");
                        $('#disctp').val("");
                        $('#disCrt').val("");
                        $('#roomrTs').val("");
                        $('#roomQty').val("");
                        $('#remarksID').val("");
                        alert("Create Successfully !!");
                        //$scope.ReserveRoomData.push({ ID: data.ID, MCATID: data.MCATID, MEDIID: data.MEDIID, MEDINM: data.MEDINM, PHARMAID: data.PHARMAID, GHEADID: data.GHEADID });
                    } else {
                        $('#RoomTypesID').val("-SELECT-");
                        $('#roomrTo').val("");
                        $('#disctp').val("");
                        $('#disCrt').val("");
                        $('#roomrTs').val("");
                        $('#roomQty').val("");
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
                $('#roomrTo').val("");
                $('#disctp').val("");
                $('#disCrt').val("");
                $('#roomrTs').val("");
                $('#roomQty').val("");
                $('#remarksID').val("");
                alert("Please Select grid level data !!");
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

        var Update = $('#txt_Updateid').val();

        if (Update == "I") {
            alert("Permission Denied!!");
            frien.editMode = false;

            //Grid view load 
            var compid = $('#txtcompid').val();
            var reserveid = $('#txt_RESVID option:selected').val();

            $http.get('/api/ApiReserveRoom/GetReserveRoomData/', {
                params: {
                    companyID: compid,
                    reserveID: reserveid,
                }
            }).success(function (data) {
                $scope.ReserveRoomData = data;
            });

            $scope.loading = false;
        }
        else {
            $http.post('/api/ApiReserveRoom/UpdateData', this.testitem).success(function (data) {
                alert("Saved Successfully!!");
                frien.editMode = false;

                //Grid view load 
                var compid = $('#txtcompid').val();
                var reserveid = $('#txt_RESVID option:selected').val();

                $http.get('/api/ApiReserveRoom/GetReserveRoomData/', {
                    params: {
                        companyID: compid,
                        reserveID: reserveid,
                    }
                }).success(function (data) {
                    $scope.ReserveRoomData = data;
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

            $http.post('/api/ApiReserveRoom/DeleteData/', this.testitem).success(function (data) {

                $.each($scope.ReserveRoomData, function (i) {
                    if ($scope.ReserveRoomData[i].ID === id) {
                        $scope.ReserveRoomData.splice(i, 1);
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





    



    $scope.RateOfferChange = function (value) {
        var discountType = this.testitem.DISCTP;
        if (discountType == "FIXED") {
            var rateoffer = this.testitem.ROOMRTO;
            var discountAmount = this.testitem.DISCRT;
            var rateNagoitated = (parseFloat(rateoffer) - (parseFloat(discountAmount))).toFixed(2);
            this.testitem.ROOMRTS = rateNagoitated;
            $('.gridRateNagotiated').val(this.testitem.ROOMRTS);
        }
        else if (discountType == "PERCENTAGE") {
            var rateoffer = this.testitem.ROOMRTO;
            var discountAmount = this.testitem.DISCRT;
            var rateNagoitated = (parseFloat(rateoffer) - ((parseFloat(rateoffer) * parseFloat(discountAmount)) / 100)).toFixed(2);
            this.testitem.ROOMRTS = rateNagoitated;
            $('.gridRateNagotiated').val(this.testitem.ROOMRTS);
        }
    }



    $scope.DiscountAmount = function (value) {
        var discountType = this.testitem.DISCTP;
        if (discountType == "FIXED") {
            var rateoffer = this.testitem.ROOMRTO;
            var discountAmount = this.testitem.DISCRT;
            var rateNagoitated = (parseFloat(rateoffer) - (parseFloat(discountAmount))).toFixed(2);
            this.testitem.ROOMRTS = rateNagoitated;
            $('.gridRateNagotiated').val(this.testitem.ROOMRTS);
        }
        else if (discountType == "PERCENTAGE") {
            var rateoffer = this.testitem.ROOMRTO;
            var discountAmount = this.testitem.DISCRT;
            var rateNagoitated = (parseFloat(rateoffer) - ((parseFloat(rateoffer) * parseFloat(discountAmount)) / 100)).toFixed(2);
            this.testitem.ROOMRTS = rateNagoitated;
            $('.gridRateNagotiated').val(this.testitem.ROOMRTS);
        }
    }

});