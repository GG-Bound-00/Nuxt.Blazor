// 主题管理 JavaScript 模块
export const NuxtTheme = {
    // 设置主题属性
    setThemeAttribute: function(theme) {
        document.documentElement.setAttribute('data-theme', theme);
    }
};

// 为了向后兼容，也把它挂到 window 对象上
window.NuxtTheme = NuxtTheme;