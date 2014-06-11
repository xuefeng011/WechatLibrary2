(function () {
    "use strict";
    Ext.onReady(function () {
        window.viewModel = window.viewModel || {
            addWindow: Ext.getCmp('addWindow'),
            modifyWindow: Ext.getCmp('modifyWindow'),
            txtNewTextMatch: Ext.getCmp('txtNewTextMatch'),
            storeTextMatches: Ext.StoreManager.get('storeTextMatches'),
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
                    window.viewModel.modifyWindow.show();
                } else if (commandName == "delete") {
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
            }
        };
    });
}());
