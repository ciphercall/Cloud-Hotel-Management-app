var RoomNoApp = angular.module("RoomNoApp", ['ui.bootstrap']);

RoomNoApp.controller("ApiRoomNoController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;


    $scope.search = function (event) {

        $scope.loading = true;
        event.preventDefault();

        var compid = $('#txtcompid').val();
        var roomTypeID = $('#ddlRoomTypeID option:selected').val();

        $http.get('/api/ApiRoomNo/GetRoomNoData/', {
            params: {
                Compid: compid,
                Rtpid: roomTypeID,
            }
        }).success(function (data) {
            if (data[0].count == 1) {
                $scope.RoomNoData = null;
            } else {
                $scope.RoomNoData = data;
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
        var roomTypeID = $('#ddlRoomTypeID option:selected').val();

        $http.get('/api/ApiRoomNo/GetRoomNoData/', {
            params: {
                Compid: compid,
                Rtpid: roomTypeID,
            }
        }).success(function (data) {
            $scope.RoomNoData = data;
            $scope.loading = false;
        });
    };




    //Add grid level data
    $scope.addrow = function (event) {
        $scope.loading = false;
        event.preventDefault();

        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#RoomNoID').val("");
            $('#RemarksID').val("");
            alert("Permission Denied!!");
        }
        else {
            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();
            this.newChild.ROOMNO = $('#RoomNoID').val();
            this.newChild.REMARKS = $('#RemarksID').val();
            this.newChild.RTPID = $('#ddlRoomTypeID option:selected').val();
            
            if (this.newChild.ROOMNO != "" && this.newChild.RTPID!="" &&    this.newChild.RTPID !=0) {
                $http.post('/api/ApiRoomNo/AddData', this.newChild).success(function (data, status, headers, config) {

                    //Grid view load 
                    var compid = $('#txtcompid').val();
                    var roomTypeID = $('#ddlRoomTypeID option:selected').val();

                    $http.get('/api/ApiRoomNo/GetRoomNoData/', {
                        params: {
                            Compid: compid,
                            Rtpid: roomTypeID,
                        }
                    }).success(function (data) {
                        $scope.RoomNoData = data;
                        $scope.loading = false;
                    });


                    if (data.ValidationError == true && data.ROOMNO != 0) {
                        $('#RoomNoID').val("");
                        $('#RemarksID').val("");
                        alert("validation error!");
                    }
                    else if (data.ROOMNO != 0 && data.ValidationError == false) {
                        $('#RoomNoID').val("");
                        $('#RemarksID').val("");
                        alert("Create Successfully !!");
                        //$scope.RoomNoData.push({ ID: data.ID, MCATID: data.MCATID, MEDIID: data.MEDIID, MEDINM: data.MEDINM, PHARMAID: data.PHARMAID, GHEADID: data.GHEADID });
                    } else if (data.ROOMNO == 0 && data.ValidationError == true) {
                        $('#RoomNoID').val("");
                        $('#RemarksID').val("");
                        alert("Duplicate name will not create!");
                    }

                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                    $scope.loading = false;
                });

            }
            else if (this.newChild.RTPID == "" || this.newChild.RTPID == 0) {
                $('#RoomNoID').val("");
                $('#RemarksID').val("");
                alert("Please select type !!");
            }
            else {
                $('#RoomNoID').val("");
                $('#RemarksID').val("");
                alert("Please input grid level data !!");
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
        this.testitem.RTPID = $('#ddlRoomTypeID option:selected').val();
        var Update = $('#txt_Updateid').val();

        if (Update == "I") {
            alert("Permission Denied!!");
            frien.editMode = false;

            //Grid view load 
            var compid = $('#txtcompid').val();
            var roomTypeID = $('#ddlRoomTypeID option:selected').val();

            $http.get('/api/ApiRoomNo/GetRoomNoData/', {
                params: {
                    Compid: compid,
                    Rtpid: roomTypeID,
                }
            }).success(function (data) {
                $scope.RoomNoData = data;
                $scope.loading = false;
            });

            $scope.loading = false;
        }
        else {
            $http.post('/api/ApiRoomNo/UpdateData', this.testitem).success(function (data) {
                if (data.MEDIID != 0) {
                    alert("Saved Successfully!!");
                } else {
                    alert("Duplicate data will not create!");
                }

                frien.editMode = false;

                //Grid view load 
                var compid = $('#txtcompid').val();
                var roomTypeID = $('#ddlRoomTypeID option:selected').val();

                $http.get('/api/ApiRoomNo/GetRoomNoData/', {
                    params: {
                        Compid: compid,
                        Rtpid: roomTypeID,
                    }
                }).success(function (data) {
                    $scope.RoomNoData = data;
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

            $http.post('/api/ApiRoomNo/DeleteData/', this.testitem).success(function (data) {

                $.each($scope.RoomNoData, function (i) {
                    if ($scope.RoomNoData[i].ID === id) {
                        $scope.RoomNoData.splice(i, 1);
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