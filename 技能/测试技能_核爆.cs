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
            int �˺�ֵ = 9999999;
            DamageInfo �˺��¼� = new DamageInfo();
            foreach (var Ŀ���ɫ in Ŀ��)
            {
                �˺��¼�.AddDamageToLast(new �˺�Ч��(�ͷ���, Ŀ���ɫ, Name, message, �˺�����.����, ��������.�����˺�, �˺�ֵ));
            }
            ս��������.GetInstance().�����˺��¼�(�˺��¼�);
        }
        public override ����״̬ �ͷźϷ��Լ��(��ɫ �ͷ���)
        {
            return ����״̬.����;
        }
    }
}
