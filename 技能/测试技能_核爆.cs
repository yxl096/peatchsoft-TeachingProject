namespace ս��С��Ϸ
{
    /// <summary>
    /// Author: ��
    /// Description: ʾ���������ܣ�������
    /// </summary>
    class ���Լ���_�˱� : ����
    {
        public ���Լ���_�˱�()
        {
            Name = "�˱�";
            �������� = "������ȫtmը��";
            ���������� = true;
            ��ЧĿ�� = ����Ŀ��.�з�ȫ��;
        }

        public override void ʹ�ü���(��ɫ �ͷ���, ��ɫ[] Ŀ��)
        {
            string message = $"{�ͷ���.Name} �����˱�";
            int �˺�ֵ = 999900000;
            �˺�Ч�� �˱� = new �˺�Ч��(�ͷ���, Ŀ��, Name, message, �˺�����.����, ��������.�����˺�, �˺�ֵ);
            ս��������.GetInstance().�����˺��¼�(new DamageInfo(�˱�));
        }
        public override ����״̬ �ͷźϷ��Լ��(��ɫ �ͷ���)
        {
            return ����״̬.����;
        }
    }
}
