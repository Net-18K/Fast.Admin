import { createApp } from "vue";
import Antd from "ant-design-vue";
import "./style/index.less";
import fast from "./fast";
import router from "./router";
import store from "./store";
import App from "./App.vue";
import "./tailwind.css";

const app = createApp(App);
app.use(store);
app.use(router);
app.use(Antd);
app.use(fast);

// 挂在app
app.mount("#app");
