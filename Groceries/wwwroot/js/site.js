//@section scripts {
//    <script type="text/javascript">
//        $(document).ready(function () {
//            $(".buttonUp").on("click", function () {
//                $(this).parent().parent().find(".stockValue").val(function (i, oldVal) {
//                    var newVal = ++oldVal;
//                    var obj = { id: $(this).data("id"), stock: newVal };
//                    saveChanges(obj);
//                    return newVal;
//                });
//            });
//        $(".buttonDown").on("click", function () {
//            $(this).parent().parent().find(".stockValue").val(function (i, oldVal) {
//                var newVal = --oldVal;
//                var obj = { id: $(this).data("id"), stock: newVal };
//                saveChanges(obj);
//                return newVal;
//            });
//        });
//        var saveChanges = function (item) {
//            if (item.stock <= -1) return;
//            $(this).parent().parent().find(".stockValue").val(function (i, oldval) {});
//            $.ajax({
//            item: item,
//                type: "POST",
//                url: '@Url.Action("EditStock", "Groceries")',
//                data: 'id='+item.id+'&stock='+item.stock,
//                success: function (response) {
//            console.log("saved");
//        },
//                error: function () {
//        }
//        });
//        }
//    });
//    </script>
//}