function updateSignatureCount(causeId, newSignatureCount) {
    $.ajax({
        url: '/Cause/UpdateSignatureCount',
        type: 'POST',
        data: { id: causeId, signatureCount: newSignatureCount },
        success: function (data) {
            if (data.success) {
                alert('Signature count updated successfully!');
            } else {
                alert('An error occurred: ' + data.message);
            }
        },
        error: function () {
            alert('An error occurred while processing your request.');
        }
    });
}
