$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'books/createmodal');
    var editModal = new abp.ModalManager(abp.appPath + 'Books/EditModal');

    var dataTable = $('#BooksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(bookStore.books.book.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted("BookStore.Books.Edit"),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }

                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted("BookStore.Books.Delete"),
                                    confirmMessage: function (data) {
                                        console.log(data);
                                        return l('BookDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        acme.bookStore.books.book
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Type'),
                    data: "type",
                    render: function (data) {
                        return l([
                            "Enum:BookType.Undefined",
                            "Enum:BookType.Adventure",
                            "Enum:BookType.Biography",
                            "Enum:BookType.Dystopia",
                            "Enum:BookType.Fantastic",
                            "Enum:BookType.Horror",
                            "Enum:BookType.Science",
                            "Enum:BookType.ScienceFiction",
                            "Enum:BookType.Poetry"
                        ][data]);
                    }
                },
                {
                    title: l('PublishDate'),
                    data: "publishDate",
                    dataFormat: "datetime"
                },
                {
                    title: l('Price'),
                    data: "price"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    dataFormat: "datetime"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewBookButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
