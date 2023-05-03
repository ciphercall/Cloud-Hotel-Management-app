var RoomStatus = angular.module("RoomStatus", ['ui.bootstrap']);

RoomStatus.controller("ApiRoomStatusController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;

  

    // Inital Grid view load 
    var compid = $('#txtcompid').val();
    $http.get('/api/ApiRoomStatus/GetData/', {
        params: {
            Compid: compid
        }
    }).success(function (data) {
        if (data[0].count == 1) {
            $scope.GetData = null;
        } else {
            $scope.GetData = data;
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
        $http.get('/api/ApiRoomStatus/GetData/', {
            params: {
                Compid: compid1,
            }
        }).success(function (data) {
            $scope.GetData = data;
            $scope.loading = false;
        });
    };





    //Add grid level data
    $scope.addrow = function (event) {
        $scope.loading = false;
        event.preventDefault();

        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#CLastDate').val("");
            $('#CNextDate').val("");
            $('#RemarksID').val("");
            alert("Permission Denied!!");
        }
        else {
            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();
            this.newChild.ROOMNO = $('#RoomNoID').val();
            this.newChild.RSTATS = $('#RStatus').val();
            this.newChild.CSTATS = $('#CStatus').val();
            this.newChild.CLASTDT = $('#CLastDate').val();
            this.newChild.CNEXTDT = $('#CNextDate').val();
            this.newChild.REMARKS = $('#RemarksID').val();

            if (this.newChild.ROOMNO != "" && this.newChild.ROOMNO != 0 && this.newChild.RStatus != "" && this.newChild.CSTATS != "" && this.newChild.CLASTDT != "" && this.newChild.CNEXTDT != "") {
                $http.post('/api/ApiRoomStatus/AddData', this.newChild).success(function (data, status, headers, config) {

                    //Grid view load 
                    var compid2 = $('#txtcompid').val();
                    $http.get('/api/ApiRoomStatus/GetData/', {
                        params: {
                            Compid: compid2,
                        }
                    }).success(function (data) {
                        $scope.GetData = data;
                        $scope.loading = false;
                    });


                    if (data.ROOMNO != 0) {
                        $('#CLastDate').val("");
                        $('#CNextDate').val("");
                        $('#RemarksID').val("");
                        alert("Create Successfully !!");
                        //$scope.GetData.push({ ID: data.ID, MCATID: data.MCATID, MCATNM: data.MCATNM });
                    }  else {
                        $('#CLastDate').val("");
                        $('#CNextDate').val("");
                        $('#RemarksID').val("");
                        alert("Duplicate name will not create!");
                    }

                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                    $scope.loading = false;
                });

            }
            else {
                alert("Please input required field !!");
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
        this.testitem.CLASTDT = $('#gridCLastDate').val();
        this.testitem.CNEXTDT = $('#gridCNextDate').val();

        var Update = $('#txt_Updateid').val();

        if (Update == "I") {
            alert("Permission Denied!!");
            frien.editMode = false;

            //Grid view load 
            var compid3 = $('#txtcompid').val();
            $http.get('/api/ApiRoomStatus/GetData/', {
                params: {
                    Compid: compid3,
                }
            }).success(function (data) {
                $scope.GetData = data;
            });

            $scope.loading = false;
        }
        else {
            if (this.testitem.ROOMNO != "" && this.testitem.ROOMNO != 0 && this.testitem.RStatus != "" && this.testitem.CSTATS != "" && this.testitem.CLASTDT != "" && this.testitem.CNEXTDT != "") {
                $http.post('/api/ApiRoomStatus/UpdateData', this.testitem).success(function (data) {
                    alert("Saved Successfully!!");
                    frien.editMode = false;

                    //Grid view load 
                    var compid4 = $('#txtcompid').val();
                    $http.get('/api/ApiRoomStatus/GetData/', {
                        params: {
                            Compid: compid4,
                        }
                    }).success(function (data) {
                        $scope.GetData = data;
                    });

                    $scope.loading = false;

                }).error(function (data) {
                    $scope.error = "An Error has occured while Saving Friend! " + data;
                    $scope.loading = false;

                });


            }
            else {
                alert("Please input required field !!");
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

            $http.post('/api/ApiRoomStatus/DeleteData', this.testitem).success(function (data) {

                var getChildDataForDeleteMasterCategory = data.GetChildDataForDeleteMasterCategory;
                if (getChildDataForDeleteMasterCategory == 1) {
                    $scope.loading = false;
                    alert("Please firstly delete category wise child data first!!");
                }
                else {
                    $.each($scope.GetData, function (i) {
                        if ($scope.GetData[i].ID === id) {
                            $scope.GetData.splice(i, 1);
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