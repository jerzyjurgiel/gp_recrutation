export interface ChatMessage{
    id: number;
    message: string;
    approval:boolean | null; 
    isAI :boolean;
    isLoading: boolean; 
    chatId?: number | null;
}