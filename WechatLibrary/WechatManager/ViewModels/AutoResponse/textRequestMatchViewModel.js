(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            addWindow: Ext.getCmp('addWindow'),
            modifyWindow: Ext.getCmp('modifyWindow'),
            txtNewTextMatch: Ext.getCmp('txtNewTextMatch'),
            storeTextMatches: Ext.StoreManager.get('storeTextMatches'),
            txtModifyTextMatchContent: Ext.getCmp('txtModifyTextMatchContent'),
            cmbModifyTextMatchOption: Ext.getCmp('cmbModifyTextMatchOption'),
            cmbResponseType: Ext.getCmp('cmbResponseType'),
            cmbResponseTextMessage: Ext.getCmp('cmbResponseTextMessage'),
            cmbResponseImageMessage: Ext.getCmp('cmbResponseImageMessage'),
            cmbResponseNewsMessage: Ext.getCmp('cmbResponseNewsMessage'),
            txtModifyTextMatchLevel: Ext.getCmp('txtModifyTextMatchLevel'),
            cmbResponseTypeSelected: function (parameters) {
                var selectedValue = window.viewModel.cmbResponseType.value;
                if (selectedValue == '文本') {

                } else if (selectedValue == '图片') {
                } else if (selectedValue == '图文') {
                }
            },
            addNewWehcatTextRequestMatchCommand: function (parameters) {
                window.viewModel.txtNewTextMatch.setRawValue('');
                window.viewModel.addWindow.show();
            },
            saveNewWechatTextRequestMatchCommand: function (parameters) {
                Ext.Ajax.request({
                    url: '/Service/TextRequestMatchService/Add.ashx',
                    method: 'POST',
                    params: {
                        Content: window.viewModel.txtNewTextMatch.getRawValue()
                    },
                    success: function (response, options) {
                        var responseText = response.responseText;
                        var responseObj = Ext.decode(responseText);
                        if (responseObj.success) {
                            Ext.Msg.alert('Success', responseObj.info, function () {
                                window.viewModel.storeTextMatches.load();
                                window.viewModel.addWindow.close();
                            });
                        } else {
                            Ext.Msg.alert('Error', responseObj.info);
                        }
                    },
                    failure: function (response, options) {
                        Ext.Msg.alert('Error', 'add failed!');
                    }
                });
            },
            textMatchesCommandClickCommand: function (parameters) {
                var commandName = parameters[1];
                var data = parameters[2].data;

                if (commandName == "modify") {
                    Ext.Ajax.request({
                        url: '/Service/TextRequestMatchService/GetById.ashx',
                        method: 'POST',
                        params: { Id: data.Id },
                        success: function (response, options) {
                            var responseText = response.responseText;
                            var responseObj = Ext.decode(responseText);
                            if (responseObj.success) {
                                // Get the text match data from json object.
                                var data = responseObj.data;

                                // Set each control value;
                                window.viewModel.txtModifyTextMatchContent.setRawValue(data.MatchContent);
                                var matchOption = data.MatchOption;
                                if (matchOption == 'equals') {
                                    window.viewModel.cmbModifyTextMatchOption.select('完全匹配');
                                } else if (matchOption == 'equalsignore') {
                                    window.viewModel.cmbModifyTextMatchOption.select('不区分大小写完全匹配');
                                } else if (matchOption == 'contains') {
                                    window.viewModel.cmbModifyTextMatchOption.select('部分匹配');
                                } else if (matchOption == 'containsignore') {
                                    window.viewModel.cmbModifyTextMatchOption.select('不区分大小写部分匹配');
                                } else {
                                    window.viewModel.cmbModifyTextMatchOption.select('');
                                }
                                window.viewModel.txtModifyTextMatchLevel.setRawValue(data.MatchLevel);


                                // Show the setting window.
                                window.viewModel.modifyWindow.show();
                            } else {
                                Ext.Msg.alert('Error', responseObj.info);
                            }
                        },
                        failure: function (response, options) {
                            Ext.Msg.alert('Error', 'load information fail!');
                        }
                    });
                } else if (commandName == "delete") {
                    Ext.Msg.confirm('Warning', 'make sure to delete this match?', function (btn) {
                        if (btn == 'yes') {
                            Ext.Ajax.request({
                                url: '/Service/TextRequestMatchService/Delete.ashx',
                                method: 'POST',
                                params: {
                                    Id: data.Id
                                },
                                success: function (response, options) {
                                    var responseText = response.responseText;
                                    var responseObj = Ext.decode(responseText);
                                    if (responseObj.success) {
                                        Ext.Msg.alert('Success', responseObj.info, function () {
                                            // Refresh the grid panel.
                                            window.viewModel.storeTextMatches.load();
                                        });
                                    } else {
                                        Ext.Msg.alert('Error', responseObj.info);
                                    }
                                },
                                failure: function (response, options) {
                                    Ext.Msg.alert('Error', 'delete fail!');
                                }
                            });
                        }
                    });
                }
            }
        };
    });
}());
