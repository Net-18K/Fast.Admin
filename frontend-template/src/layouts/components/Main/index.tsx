import { defineComponent, ref, reactive, onMounted, watch, onBeforeMount, onUnmounted, nextTick, provide, Transition, KeepAlive } from "vue";
import { useRoute, type RouteLocationNormalized } from "vue-router";
import useCurrentInstance from "@/hooks/useCurrentInstance";
import { useConfig } from "@/stores/config";
import { useNavTabs } from "@/stores/navTabs";
import type { ScrollbarInstance } from "element-plus";

export default defineComponent({
    name: "LayoutMain",
    setup() {
        const { proxy } = useCurrentInstance();

        const route = useRoute();
        const configStore = useConfig();
        const navTabsStore = useNavTabs();
        const mainScrollbarRef = ref<ScrollbarInstance>();

        const state: {
            componentKey: string;
            keepAliveComponentNameList: string[];
        } = reactive({
            componentKey: route.path,
            keepAliveComponentNameList: [],
        });

        const addKeepAliveComponentName = function (keepAliveName: string | undefined) {
            if (keepAliveName) {
                let exist = state.keepAliveComponentNameList.find((name: string) => {
                    return name === keepAliveName;
                });
                if (exist) return;
                state.keepAliveComponentNameList.push(keepAliveName);
            }
        };

        onBeforeMount(() => {
            proxy.eventBus.on("onTabViewRefresh", (menu: RouteLocationNormalized) => {
                state.keepAliveComponentNameList = state.keepAliveComponentNameList.filter((name: string) => menu.path !== name);
                state.componentKey = "";
                nextTick(() => {
                    state.componentKey = menu.path;
                    addKeepAliveComponentName(menu.path);
                });
            });
            proxy.eventBus.on("onTabViewClose", (menu: RouteLocationNormalized) => {
                state.keepAliveComponentNameList = state.keepAliveComponentNameList.filter((name: string) => menu.path !== name);
            });
        });

        onUnmounted(() => {
            proxy.eventBus.off("onTabViewRefresh");
            proxy.eventBus.off("onTabViewClose");
        });

        onMounted(() => {
            // 确保刷新页面时也能正确取得当前路由 keepalive 参数
            if (navTabsStore.state.activeTab.meta.keepAlive) {
                addKeepAliveComponentName(navTabsStore.state.activeTab.path);
            }
        });

        watch(
            () => route.path,
            () => {
                state.componentKey = route.path;
                if (navTabsStore.state.activeTab.meta.keepAlive) {
                    addKeepAliveComponentName(navTabsStore.state.activeTab.path);
                }
            }
        );

        provide("mainScrollbarRef", mainScrollbarRef);

        return () => (
            <el-main class="fast-layout-main">
                <el-scrollbar
                    ref={mainScrollbarRef}
                    class="fast-layout-main-scrollbar"
                >
                    <router-view>
                        {{
                            default: ({ Component }) => (
                                <Transition
                                    mode="out-in"
                                    name={configStore.layout.mainAnimation}
                                >
                                    <KeepAlive include={state.keepAliveComponentNameList}>
                                        <Component key={state.componentKey} class="fast-layout-main-container" />
                                    </KeepAlive>
                                </Transition>
                            )
                        }}
                    </router-view>
                </el-scrollbar>
            </el-main>
        );
    },
});
