import "./style/index.scss";
import type { ContextMenuItem } from "./interface";
export declare const FContextMenu: import("vue").DefineComponent<{
    width: {
        type: NumberConstructor;
        default: number;
    };
    items: {
        type: {
            (arrayLength: number): ContextMenuItem[];
            (...items: ContextMenuItem[]): ContextMenuItem[];
            new (arrayLength: number): ContextMenuItem[];
            new (...items: ContextMenuItem[]): ContextMenuItem[];
            isArray(arg: any): arg is any[];
            readonly prototype: any[];
            from<T>(arrayLike: ArrayLike<T>): T[];
            from<T_1, U>(arrayLike: ArrayLike<T_1>, mapfn: (v: T_1, k: number) => U, thisArg?: any): U[];
            from<T_2>(iterable: Iterable<T_2> | ArrayLike<T_2>): T_2[];
            from<T_3, U_1>(iterable: Iterable<T_3> | ArrayLike<T_3>, mapfn: (v: T_3, k: number) => U_1, thisArg?: any): U_1[];
            of<T_4>(...items: T_4[]): T_4[];
            readonly [Symbol.species]: ArrayConstructor;
        };
        require: boolean;
    };
}, () => any, unknown, {}, {}, import("vue").ComponentOptionsMixin, import("vue").ComponentOptionsMixin, {}, string, import("vue").PublicProps, Readonly<import("vue").ExtractPropTypes<{
    width: {
        type: NumberConstructor;
        default: number;
    };
    items: {
        type: {
            (arrayLength: number): ContextMenuItem[];
            (...items: ContextMenuItem[]): ContextMenuItem[];
            new (arrayLength: number): ContextMenuItem[];
            new (...items: ContextMenuItem[]): ContextMenuItem[];
            isArray(arg: any): arg is any[];
            readonly prototype: any[];
            from<T>(arrayLike: ArrayLike<T>): T[];
            from<T_1, U>(arrayLike: ArrayLike<T_1>, mapfn: (v: T_1, k: number) => U, thisArg?: any): U[];
            from<T_2>(iterable: Iterable<T_2> | ArrayLike<T_2>): T_2[];
            from<T_3, U_1>(iterable: Iterable<T_3> | ArrayLike<T_3>, mapfn: (v: T_3, k: number) => U_1, thisArg?: any): U_1[];
            of<T_4>(...items: T_4[]): T_4[];
            readonly [Symbol.species]: ArrayConstructor;
        };
        require: boolean;
    };
}>>, {
    width: number;
}, {}>;
