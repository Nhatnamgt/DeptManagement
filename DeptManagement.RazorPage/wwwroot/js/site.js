window.AppUtils = (function () {
    function escapeHtml(text) {
        if (!text) return '';
        const div = document.createElement('div');
        div.textContent = text;
        return div.innerHTML;
    }

    function formatMoney(value) {
        return Number(value || 0).toLocaleString('vi-VN');
    }

    function formatDate(value) {
        if (!value) return '<span class="text-muted">—</span>';
        return escapeHtml(value);
    }

    function formatNote(text, maxLen = 60) {
        if (!text || !text.trim()) {
            return '<span class="text-muted">—</span>';
        }
        const trimmed = text.trim();
        const escaped = escapeHtml(trimmed);
        const display = trimmed.length > maxLen
            ? escapeHtml(trimmed.substring(0, maxLen)) + '…'
            : escaped;
        return `<span class="note-cell" title="${escaped}">${display}</span>`;
    }

    function showAlert(containerId, message, type = 'success') {
        const container = document.getElementById(containerId);
        if (!container) return;
        container.innerHTML =
            `<div class="alert alert-${type} alert-dismissible fade show" role="alert">
                ${escapeHtml(message)}
                <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
            </div>`;
        setTimeout(() => {
            const alert = container.querySelector('.alert');
            if (alert) bootstrap.Alert.getOrCreateInstance(alert).close();
        }, 4000);
    }

    return { escapeHtml, formatMoney, formatDate, formatNote, showAlert };
})();
