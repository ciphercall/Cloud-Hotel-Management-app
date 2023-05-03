var CItemApp = angular.module("CItemApp", ['ui.bootstrap']);

CItemApp.controller("ApiCItemController", function ($scope, $http) {

    $scope.loading = false;
    $scope.addMode = false;


    // Inital Grid view load 
    var compid = $('#txtcompid').val();
    $http.get('/api/ApiCItem/GetData/', {
        params: {
            Compid: compid
        }
    }).success(function (data) {
        if (data[0].count == 1) {
            $scope.CItemData = null;
        } else {
            $scope.CItemData = data;
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
        $http.get('/api/ApiCItem/GetData/', {
            params: {
                Compid: compid1,
            }
        }).success(function (data) {
            $scope.CItemData = data;
            $scope.loading = false;
        });
    };





    //Add grid level data
    $scope.addrow = function (event) {
        $scope.loading = false;
        event.preventDefault();

        var insert = $('#txt_Insertid').val();
        if (insert == "I") {
            $('#CItemNameid').val("");
            $('#defynID').val("");
            alert("Permission Denied!!");
        }
        else {
            this.newChild.COMPID = $('#txtcompid').val();
            this.newChild.INSUSERID = $('#txtInsertUserid').val();
            this.newChild.INSLTUDE = $('#latlon').val();
            this.newChild.CITEMNM = $('#CItemNameid').val();
            this.newChild.DEFYN = $('#defynID').val();
            if (this.newChild.RTPNM != "") {
                $http.post('/api/ApiCItem/AddData', this.newChild).success(function (data, status, headers, config) {

                    //Grid view load 
                    var compid2 = $('#txtcompid').val();
                    $http.get('/api/ApiCItem/GetData/', {
                        params: {
                            Compid: compid2,
                        }
                    }).success(function (data) {
                        $scope.CItemData = data;
                        $scope.loading = false;
                    });


                    if (data.CITEMID != 0) {
                        $('#CItemNameid').val("");
                        $('#defynID').val("");
                        alert("Create Successfully !!");
                    } else if (data.ValidationError == true) {
                        $('#CItemNameid').val("");
                        $('#defynID').val("");
                        alert("Validation Error!");
                    } else {
                        $('#CItemNameid').val("");
                        $('#defynID').val("");
                        alert("Duplicate name will not create!");
                    }



                }).error(function () {
                    $scope.error = "An Error has occured while loading posts!";
                    $scope.loading = false;
                });

            }
            else {
                $('#CItemNameid').val("");
                $('#defynID').val("");
                alert("Please input Complementary Item name field !!");
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
            $http.get('/api/ApiCItem/GetData/', {
                params: {
                    Compid: compid3,
                }
            }).success(function (data) {
                $scope.CItemData = data;
            });

            $scope.loading = false;
        }
        else {
            $http.post('/api/ApiCItem/UpdateData', this.testitem).success(function (data) {
                alert("Saved Successfully!!");
                frien.editMode = false;

                //Grid view load 
                var compid4 = $('#txtcompid').val();
                $http.get('/api/ApiCItem/GetData/', {
                    params: {
                        Compid: compid4,
                    }
                }).success(function (data) {
                    $scope.CItemData = data;
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

            $http.post('/api/ApiCItem/DeleteData', this.testitem).success(function (data) {

                var getChildDataForDeleteMasterCategory = data.GetChildDataForDeleteMasterCategory;
                if (getChildDataForDeleteMasterCategory == 1) {
                    $scope.loading = false;
                    alert("Please firstly delete category wise child data first!!");
                }
                else {
                    $.each($scope.CItemData, function (i) {
                        if ($scope.CItemData[i].ID === id) {
                            $scope.CItemData.splice(i, 1);
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