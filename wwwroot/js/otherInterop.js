window.otherInterop = {
  copy: async (text) => {
    if (!navigator.clipboard) {
      console.error("Clipboard API not available");
      return;
    }
    try {
      await navigator.clipboard.writeText(text);
    } catch (err) {
      console.error("Failed to copy!", err);
    }
  },
  scrollToBottom: (selector) => {
    const element = document.querySelector(selector);
    if (element) {
      setTimeout(() => {
        element.scrollTop = element.scrollHeight;
      }, 500);
    }
  },
};
