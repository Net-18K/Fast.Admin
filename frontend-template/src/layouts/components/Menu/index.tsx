import { SetupContext, defineComponent, nextTick, onMounted, reactive, ref } from "vue";
import { useRoute, onBeforeRouteUpdate, type RouteLocationNormalizedLoaded } from 'vue-router'
import { useConfig } from "@/stores/config";
import { useNavTabs } from "@/stores/navTabs";
import LayoutMenuItem from "@/layouts/components/MenuItem";

export default defineComponent({
    name: "LayoutMenu",
    setup(_, { attrs }: SetupContext) {
        const configStore = useConfig();
        const navTabsStore = useNavTabs();
        const route = useRoute()

        const menusRef = ref();

        const state = reactive({
            defaultActive: '',
        })

        /**
         * 激活当前路由的菜单
         * @param currentRoute 
         */
        const currentRouteActive = (currentRoute: RouteLocationNormalizedLoaded) => {
            state.defaultActive = `${currentRoute.meta.menuId}`;
        }

        /**
         * 滚动条滚动到激活菜单所在位置
         */
        const verticalMenusScroll = () => {
            nextTick(() => {
                let activeMenu: HTMLElement | null = document.querySelector('.el-menu.fast-layout-menu li.is-active')
                if (!activeMenu) return false
                menusRef.value?.setScrollTop(activeMenu.offsetTop)
            })
        }

        onMounted(() => {
            currentRouteActive(route)
            verticalMenusScroll()
        })

        onBeforeRouteUpdate((to) => {
            currentRouteActive(to)
        })

        return () => (
            <el-scrollbar ref={menusRef} class="fast-layout-menu-scrollbar">
                <el-menu
                    {...attrs}
                    class="fast-layout-menu"
                    collapseTransition={false}
                    uniqueOpened={configStore.layout.menuUniqueOpened}
                    defaultActive={state.defaultActive}
                    collapse={configStore.layout.menuCollapse}
                >
                    <LayoutMenuItem menus={navTabsStore.state.tabs} />
                </el-menu>
            </el-scrollbar>
        );
    },
});
