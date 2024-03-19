export interface AppModalState {
  visible: boolean | false;
  title: string | undefined;
  actionId: number | 0;
  data?: any | undefined;
  okButtonText?: string | undefined;
}
